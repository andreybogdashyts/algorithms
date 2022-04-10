import React, { useState, useEffect }  from "react";


const Highlighter = () => {
  var highlight = function(input, regexes) {
        if (!regexes.length) {
            return input;
        }
        let split = input.split(regexes[0]);
        let repls = input.match(regexes[0]);
        let r = [];
        for (let i = 0; i < split.length - 1; i++) {
            r.push(highlight(split[i], regexes.slice(1)));
            r.push(<mark>{repls[i]}</mark>);
        }
        r.push(highlight(split[split.length - 1], regexes.slice(1)));
        return r;
   }
  const [result, setResult] = useState("")
  const [initialText, setInitialText] = useState("")
  const [searchText, setSearchText] = useState("")
  const [caseSensetive, setCaseSensetive] = useState(false)
 
  useEffect(()=> {
    setResult(apply(searchText));
  }, [initialText])

  useEffect(()=> {
    setResult(apply(searchText));
  }, [caseSensetive])

  var handleChange = function(event) {
    setInitialText(event.target.value);
  }
  var handleCaseSensetiveChange = function(){
    setCaseSensetive(!caseSensetive)

  }
  var handleSearch = function(event){
    let text = event.target.value
    setSearchText(text);
    setResult(apply(text));
  }
  var apply = function(searchText){
    let regexes = searchText.split(" ").map(word => new RegExp(`${word}`, caseSensetive ? 'g' : 'ig'));
    return highlight(initialText, regexes)
  }
  return (
    <>
      <div><textarea className="line main-text" data-testid="source-text" value={initialText} onChange={handleChange}/></div>
      <div><input className="line" data-testid="search-term" value={searchText} onChange={handleSearch}/></div>
      <div>case sensitive?  <input type="checkbox" data-testid="case-sensitive" checked={caseSensetive} onChange={handleCaseSensetiveChange}/></div>     
      <div className="line" data-testid="result">{result}</div>
    </>
  );
};

export default Highlighter;