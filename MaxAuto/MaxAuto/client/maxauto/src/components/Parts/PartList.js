import React, { useState, useEffect } from "react";
import { Part } from "./Part.js";
import { Container } from "reactstrap";
import { getAllParts } from "../../APIManagers/PartManager.js";
// import './CarList.css';


 export const PartList = () => {
	const [parts, setParts] = useState([]);
  
	const getParts = () => getAllParts().then(allParts => setParts(allParts)); 
	;
  
	const updatePartsState = () => {
	  return getAllParts()
	  .then((partArray) => {
		  setParts(partArray)
	  })
	}
	useEffect(() => {
	  getParts();
	}, []); 
	return (
	  <div className='rows' >
		<div className="row">
		  <div className="row" >
			{parts.map((part) => (
			  <Part key={part.id} part={part}/>
			))}
		  </div>
		</div>
	  </div>
	);
  };