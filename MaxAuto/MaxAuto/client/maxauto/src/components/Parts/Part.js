import React, { useState } from "react";
import { Card, CardImg, CardBody, Button } from "reactstrap";
import { Link, useNavigate, useParams } from "react-router-dom";
import { buyCarPart } from "../../APIManagers/CarPartManager";
import { GarageCar } from "../Garage/GarageCar";
import { updateMoney } from "../../Managers/UserManager";
// import './Car.css';

export const Part = ({ part }) => {
  

  const navigate = useNavigate();
  const goToGaragePage = () => {

    
     navigate('/my-garage');
    window.location.reload();

  }
  const { garageCarId } = useParams();
	const user = JSON.parse(localStorage.getItem("user"))

  const [carPart, setCarPart] = useState({
    GarageCarPartId: 0,
    GarageCarId: 0


  })


  const savePart = () => {

    if (user.money >= part.price) {


      carPart.GarageCarPartId = part.id;
      carPart.GarageCarId = garageCarId;

      buyCarPart(carPart);




			user.money -= part.price;

			updateMoney(user);

			localStorage.setItem("user", JSON.stringify(user))
			console.log(user);

			goToGaragePage()


    } else {
      window.alert(`insufficient funds, you need ${part.price}`)
      }

  }








  return (
    <Card className='h-10' style={{margin: "2em", width:" 35%", height:"auto", background: "#727272"}}>
      <p className="text-center" style={{paddingTop: "2vh", fontSize: "2rem", color: "white"}}>
        <p className="text-left px-2">{part?.name}</p>
		<p className="text-left px-2">Category: {part?.category}</p>
		{/* <p className="text-left px-2"> Mileage: {car?.mileage} </p> */}
      </p>
      {/* <CardImg className="Shadow" top src={car.imageUrl} alt={car.name}  /> */}
      <CardBody >
        <p>debug PartId: {part.id} debug GarageCarId: {garageCarId}  </p>
         <p>
          <p style={{color:"white"}}>
          <strong> ${part.price}.00</strong>
          </p>
          <Button onClick={savePart

              // GRAB GARAGECAR ID, GRAB PART ID, ADD THEM TO CARPART, SAVE WITH THE BUYCARPART FUNCTION

          }
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