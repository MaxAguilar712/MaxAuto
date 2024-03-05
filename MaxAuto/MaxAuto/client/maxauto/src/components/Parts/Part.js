import React from "react";
import { Card, CardImg, CardBody, Button } from "reactstrap";
import { Link } from "react-router-dom";
// import './Car.css';

export const Part = ({ part }) => {
  return (
    <Card className='h-10' style={{margin: "2em", width:" 35%", height:"auto", background: "#727272"}}>
      <p className="text-center" style={{paddingTop: "2vh", fontSize: "2rem", color: "white"}}>
        <p className="text-left px-2">{part?.name}</p>
		<p className="text-left px-2">Category: {part?.category}</p>
		{/* <p className="text-left px-2"> Mileage: {car?.mileage} </p> */}
      </p>
      {/* <CardImg className="Shadow" top src={car.imageUrl} alt={car.name}  /> */}
      <CardBody >
         <p>
          <p style={{color:"white"}}>
          <strong> ${part.price}.00</strong>
          </p>
          <Button onClick={""}
					Dark
					color='Dark'
					className='me-2 btn-dark'
				>
					Purchase
				</Button>
        </p>
      </CardBody>
    </Card>
  );
};