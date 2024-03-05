import React, { useEffect, useState } from "react";
import { Card, CardImg, CardBody, CardFooter, Button } from "reactstrap";
import { buyGarageCar } from "../../APIManagers/GarageManager"; 
import { Link } from "react-router-dom";
import './Car.css';
import User from "../UserProfile/UserProfile";
import { updateMoney } from "../../Managers/UserManager";

export const Car = ({ car }) => {

	// const [user, setUsers] = useState([]);


	const user = JSON.parse(localStorage.getItem("user"))


	const [garageCar, setGarageCar] = useState({
		Price: 0,
		Year: 0,
		Name: "",
		Transmission: "",
		Manufacturer: "",
	    Mileage: 0,
		ImageUrl: "",
		Worth: 0
	  })





	const saveCar = () => {

		if (user.money >= car.price) {
		

		garageCar.Price = car.price;
		garageCar.Year = car.year;
		garageCar.Name = car.name;
		garageCar.Transmission = car.transmission;
		garageCar.Manufacturer = car.manufacturer;
		garageCar.Mileage = car.mileage;
		garageCar.ImageUrl = car.imageUrl;
		garageCar.Worth = car.worth;

		// console.log(garageCar)
		buyGarageCar(garageCar);
			





			user.money -= car.price;

			updateMoney(user);

			localStorage.setItem("user", JSON.stringify(user))
			console.log(user);

			

	} else {
		window.alert(`insufficient funds, you need ${car.price}`)
		}
	  };

  return (
    <Card className='h-10' style={{margin: "1.5em", width:" 500px", height:"auto", background: "#727272"}}> 
	     <CardBody >      </CardBody>
      <CardImg className="Shadow" style={{margin: "2vh"}} top src={car.imageUrl} alt={car.name}  />
	  <div className="text-center" style={{paddingTop: "1vh", fontSize: "3vh ", color: "white"}}>
        <p className="text-left px-2">{car?.year} {car?.manufacturer} {car?.name}</p>
		<p className="text-left px-2">Transmission: {car?.transmission}</p>
		<p className="text-left px-2"> Mileage: {car?.mileage} </p>
      </div>
      

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

	  <CardFooter>  
		        <p style={{color:"white"}}>
          		<strong> ${car.price}.00  </strong>
				  <Button onClick={saveCar}
					Dark
					color='Dark'
					className='me-2 btn-dark'
				>
					Purchase
				</Button></p>
			</CardFooter>
    </Card>
  );
};