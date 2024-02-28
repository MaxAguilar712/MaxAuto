import React from "react";
import { Card, CardImg, CardBody } from "reactstrap";
import { Link } from "react-router-dom";
import './Car.css';

export const Car = ({ car }) => {
  return (
    <Card className='h-10' style={{margin: "2em", width:" 35%", height:"auto", background: "#727272"}}>
      <p className="text-center" style={{paddingTop: "2vh", fontSize: "2rem", color: "white"}}>
        <p className="text-left px-2">{car?.year} {car?.manufacturer} {car?.name}</p>
		<p className="text-left px-2">Transmission: {car?.transmission}</p>
		<p className="text-left px-2"> Mileage: {car?.mileage} </p>
      </p>
      <CardImg className="Shadow" top src={car.imageUrl} alt={car.name}  />
      <CardBody >
         <p>
          <p style={{color:"white"}}>
          <strong> ${car.price}.00</strong>
          </p>
        </p>
        {/* <p>{car.caption}</p> */}
        {/* <p>Comments:</p>
        <div>
            {post.comments?.map((singleComment) => (
                <>
                <p>{singleComment.message}</p>
                <p>{singleComment?.userProfile?.name}</p>
                </>
            ))}
        </div>  */}
      </CardBody>
    </Card>
  );
};