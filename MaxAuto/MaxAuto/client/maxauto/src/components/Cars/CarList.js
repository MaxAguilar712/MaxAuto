import React, { useState, useEffect } from "react";
import { Car } from "./Car.js";
import { Container } from "reactstrap";
import { getAllCars } from "../../APIManagers/CarManager.js";
import './CarList.css';


 export const CarList = () => {
	const [cars, setCars] = useState([]);
  
	const getCars = () => getAllCars().then(allCars => setCars(allCars)); 
	;
  
	const updateCarsState = () => {
	  return getAllCars()
	  .then((carArray) => {
		  setCars(carArray)
	  })
	}
	useEffect(() => {
	  getCars();
	}, []); 
	return (
	  <div className="container">
		<div className="row">
		  <div className="cards-row">
		  {/* <CarForm updateCarsState = {getCars}/>
		  <CarSearch /> */}
			{cars.map((car) => (
			  <Car key={car.id} car={car}/>
			))}
		  </div>
		</div>
	  </div>
	);
  };
  
