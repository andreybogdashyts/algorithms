import React from "react";
import {
  cleanup,
  fireEvent,
  render,
} from "@testing-library/react";
import "@testing-library/jest-dom/extend-expect";
import Highlighter from "../src/components/Highlighter";

let getByTestId;
let queryByTestId;
let queryByDisplayValue;
beforeEach(() => (
  {getByTestId,
   queryByTestId,
   queryByDisplayValue} = render(<Highlighter />)
));
afterEach(cleanup);
describe("Highlighter", () => {
  describe("renders correct elements", () => {
    it('should have a "source-text" textarea', () => {
      expect(queryByTestId("source-text")).toBeInTheDocument();
    });
    it('should have a "search-term" input', () => {
      expect(queryByTestId("search-term")).toBeInTheDocument();
    });
    it('should have a "result" element', () => {
      const el = queryByTestId("result");
      expect(el).toBeInTheDocument();
      expect(el).toHaveTextContent(/\s*/);
    });
    it('should have a "case-sensitive" input checkbox', () => {
      expect(queryByTestId("case-sensitive")).toBeInTheDocument();
    });
  });
  
  describe("responds correctly to all input behaviors", () => {
    it('should allow input on "source-text"', () => {
      const input = getByTestId("source-text");
      fireEvent.change(input, {target: {value: "test"}});
      expect(queryByDisplayValue("test")).toBeInTheDocument();
    });
    
    it('should reflect changes to "result"', () => {
      const input = getByTestId("source-text");
      fireEvent.change(input, {target: {value: "test 1 2"}});
      expect(getByTestId("result")).toHaveTextContent("test 1 2");
    });
    
    it('should allow input on "search-term"', () => {
      const input = getByTestId("search-term");
      fireEvent.change(input, {target: {value: "hello"}});
      expect(queryByDisplayValue("hello")).toBeInTheDocument();
    });
    
    it('should highlight search results in "result"', () => {
      fireEvent.change(getByTestId("source-text"), {target: {value: "hello world"}});
      fireEvent.change(getByTestId("search-term"), {target: {value: "o"}});
      const expected = "hell<mark>o</mark> w<mark>o</mark>rld";
      expect(getByTestId("result").innerHTML.trim()).toEqual(expected);
    });
    
    it('should respond to changes on "source-text"', () => {
      const input = getByTestId("source-text");
      fireEvent.change(input, {target: {value: "hello world"}});
      expect(queryByDisplayValue("hello world")).toBeInTheDocument();
      const value = "Hello world! Hello hellohello";
      fireEvent.change(input, {target: {value}});
      expect(queryByDisplayValue("hello world")).not.toBeInTheDocument();
      expect(queryByDisplayValue(value)).toBeInTheDocument();
    });
    
    it('should respond to changes on "search-term"', () => {
      const input = getByTestId("search-term");
      fireEvent.change(input, {target: {value: "hello world"}});
      expect(queryByDisplayValue("hello world")).toBeInTheDocument();
      const value = "Hello world! Hello hellohello";
      fireEvent.change(input, {target: {value}});
      expect(queryByDisplayValue("hello world")).not.toBeInTheDocument();
      expect(queryByDisplayValue(value)).toBeInTheDocument();
    });
    
    it('should highlight substrings of "result" case-insensitively', () => {
      const value = "Hello world! Hello hellohello";
      fireEvent.change(getByTestId("source-text"), {target: {value}});
      fireEvent.change(getByTestId("search-term"), {target: {value: "hello"}});
      const expected = "<mark>Hello</mark> world! <mark>Hello</mark> <mark>hello</mark><mark>hello</mark>";
      expect(getByTestId("result").innerHTML.trim()).toEqual(expected);
    });
    
    it('should respond to checking "case-sensitive"', () => {
      const checkbox = getByTestId("case-sensitive");
      fireEvent.click(checkbox);
      expect(checkbox.checked).toEqual(true);
    });
    
    it('should highlight substrings of "result" case-sensitively', () => {
      const value = "Hello world! Hello hellohello";
      fireEvent.change(getByTestId("source-text"), {target: {value}});
      fireEvent.click(getByTestId("case-sensitive"));
      fireEvent.change(getByTestId("search-term"), {target: {value: "Hello"}});
      const expected = "<mark>Hello</mark> world! <mark>Hello</mark> hellohello";
      expect(getByTestId("result").innerHTML.trim()).toEqual(expected);
    });
    
    it('should respond to checking ".case-sensitive" multiple times', () => {
      const checkbox = getByTestId("case-sensitive");
      fireEvent.click(checkbox);
      expect(checkbox.checked).toBe(true);
      fireEvent.click(checkbox);
      expect(checkbox.checked).toBe(false);
    });
  });
});
