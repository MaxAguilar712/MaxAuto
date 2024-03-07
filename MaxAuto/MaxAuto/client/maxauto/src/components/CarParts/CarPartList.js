import React, { useState, useEffect } from "react";
// import { Part } from "./Part.js";
import { Container } from "reactstrap";
import { getAllCarParts, getPurchasedCarParts } from "../../APIManagers/CarPartManager.js";
import { GarageCar } from "../Garage/GarageCar.js";
import { CarPart } from "./CarPart.js";
// import './CarList.css';


 export const CarPartList = (PropCarId) => {
	const [carParts, setCarParts] = useState([]);
   const [filteredCarParts, setFilteredCarParts] = useState([])
  
	 const getCarParts = () => getPurchasedCarParts().then(allCarParts => setCarParts(allCarParts)); 
	// const getCarParts = () => getPurchasedCarParts().then(allCarParts => allCarParts.forEach(part => {if(part.carId == PropCarId) { carParts.push(part) }}));

    // const getCarParts = () => getPurchasedCarParts().then(allCarParts => allCarParts.filter(part =>  {return part.carId == PropCarId}));

        // useEffect(
        //     () => {
        //         const getCarParts = carParts.filter(carPart => {
        //             return carPart.carId.startsWith(PropCarId)
        //         })
        //         setFilteredCarParts(getCarParts)
        //     },
        //     [ PropCarId ]
        // )
    
  
	// const updateCarPartsState = () => {
	//   return getPurchasedCarParts()
	//   .then((carPartArray) => {
	// 	  setCarParts(carPartArray)
	//   })
	// }
	useEffect(() => {
getCarParts()	 
	}, []); 

    useEffect(() => {
        const myParts = carParts.filter( allPart => allPart.carId === PropCarId)
        setFilteredCarParts(myParts)
    }, [carParts])
	return (

		

	 
		  <ul>
			{filteredCarParts.map((carPart) => (
			 <CarPart key={carPart.id} carPart={carPart}/> 
			))}
		  </ul>

	);
  };