import React, { useState, useEffect } from "react";
// import { Part } from "./Part.js";
import { Container } from "reactstrap";
import { getAllCarParts } from "../../APIManagers/CarPartManager.js";
import { GarageCar } from "../Garage/GarageCar.js";
import { CarPart } from "./CarPart.js";
// import './CarList.css';


 export const CarPartList = () => {
	const [carParts, setCarParts] = useState([]);
  
	const getCarParts = () => getAllCarParts().then(allCarParts => setCarParts(allCarParts)); 
	;
  
	const updateCarPartsState = () => {
	  return getAllCarParts()
	  .then((carPartArray) => {
		  setCarParts(carPartArray)
	  })
	}
	useEffect(() => {
	  getCarParts();
	}, []); 
	return (

		

	  <div className='rows' > <div> Current Car Parts: {}  </div>
		<div className="row">
		  <div className="row" >
			
			{carParts.map((carPart) => (
			  <CarPart key={carPart.id} carPart={carPart}/>
			))}
		  </div>
		</div>
	  </div>
	);
  };