package challenge

import (
	"sort"
	"strings"
)

const COLUMN_JOIN = ","
const LINE_SEPARATOR = "\n"

type Column struct {
	Values []string
}

func SortCsvColumns(csvData string) string {
	if csvData == "" {
		return ""
	}
	columns := toColumns(csvData)
	sort.Slice(columns, func(i, j int) bool {
		return strings.ToLower(columns[i].Values[0]) < strings.ToLower(columns[j].Values[0])
	})
	return toCsv(columns)
}

func toColumns(csvData string) []Column {
	lines := strings.Split(csvData, LINE_SEPARATOR)
	rows := make([][]string, len(lines))
	for i, l := range lines {
		rows[i] = strings.Split(l, COLUMN_JOIN)
	}
	columnCount := len(rows[0])
	rowsCount := len(rows)
	var columns = []Column{}
	for i := 0; i < columnCount; i++ {
		c := Column{
			Values: make([]string, rowsCount),
		}
		for j := 0; j < rowsCount; j++ {
			var v = rows[j][i]
			if v == " " || v == "" {
				c.Values[j] = ""
			} else {
				c.Values[j] = v
			}
		}
		columns = append(columns, c)
	}
	return columns
}

func toCsv(columns []Column) string {
	r := []string{}
	columnCount := len(columns)
	rowsCount := len(columns[0].Values)
	for i := 0; i < rowsCount; i++ {
		s := []string{}
		for j := 0; j < columnCount; j++ {
			s = append(s, columns[j].Values[i])
		}
		r = append(r, strings.Join(s, COLUMN_JOIN))
	}
	return strings.Join(r, LINE_SEPARATOR)
}
