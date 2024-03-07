import React, { useState, useEffect } from "react";
import { GarageCar } from "./GarageCar.js";
import { Container } from "reactstrap";
import { getAllGarageCars } from "../../APIManagers/GarageManager.js";



 export const GarageCarList = () => {
	const [garageCars, setGarageCars] = useState([]);
  
	const getGarageCars = () => getAllGarageCars().then(allGarageCars => setGarageCars(allGarageCars)); 
	;
  
	const updateGarageCarsState = () => {
	  return getAllGarageCars()
	  .then((garageCarArray) => {
		  setGarageCars(garageCarArray)
	  })
	}
	useEffect(() => {
	  getGarageCars();
	}, []); 
	return (
	  <div className='rows' >
		<div className="row">
		  <div className="row" >
		  {/* <CarForm updateCarsState = {getCars}/>
		  <CarSearch /> */}
			{garageCars.map((garageCar) => (
			  <GarageCar key={garageCar.id} garageCar={garageCar}/>
			))}
		  </div>
		</div>
	  </div>
	);
  };