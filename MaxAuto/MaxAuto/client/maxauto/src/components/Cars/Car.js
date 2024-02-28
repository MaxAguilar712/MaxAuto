import React from "react";
import { Card, CardImg, CardBody } from "reactstrap";
import { Link } from "react-router-dom";
import './Car.css';

export const Car = ({ car }) => {
  return (
    <Card style={{width:"50%", height:"auto"}}>
      <p className="makeBold">
        <p className="text-left px-2">{car?.year} {car?.manufacturer} {car?.name}</p>
		<p className="text-left px-2">Transmission: {car?.transmission}</p>
		<p className="text-left px-2"> Mileage: {car?.mileage} </p>
      </p>
      <CardImg top src={car.imageUrl} alt={car.name} />
      <CardBody>
         <p>
          <Link to={`/cars/${car.id}`}>
          <strong> ${car.price}.00</strong>
          </Link>
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