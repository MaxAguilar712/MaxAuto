import React, { useState } from "react";
import { Card, CardImg, CardBody, CardFooter, Button } from "reactstrap";
import { Links, useNavigate } from "react-router-dom";
import { updateMoney } from "../../Managers/UserManager";
import { deleteGarageCar, updateGarageCar } from "../../APIManagers/GarageManager";
import './garage.css';
import { CarPartList } from "../CarParts/CarPartList";
import { getAllCarParts } from "../../APIManagers/CarPartManager";
import { EditGarageCar } from "./garageCarEdit";



export const GarageCar = ({ garageCar }) => {

	const [inputPrice, setInputPrice] = useState("");





	const GCWorth = garageCar.worth;

	const handleChange = (e) => {
		setInputPrice(e.target.value);
	  }
	const navigate = useNavigate();

	const handleNavigate = (e) => {
		e.preventDefault();
		const [, garageCarId] = e.target.id.split("--");
		if (e.target.id.startsWith("edit-garageCar")) {
			navigate(`/my-garage/EditNickName/${garageCarId}`);
		}
	};

	// const goToPartPage = () => {
	const user = JSON.parse(localStorage.getItem("user"))

		
	// 	 navigate('/part-market');
	// 	window.location.reload();

	// }



	// const buyCar = () => {


	// 	console.log(car)
	// 	assertModuleDeclaration(car);
	// }





  return (
    <Card className='h-10' style={{margin: "1.5em", width:" 375px", height:"auto", background: "#727272"}}> 
	     {/* <CardBody >      </CardBody> */}
      <CardImg className="Shadow" style={{margin: "2vh"}} top src={garageCar.imageUrl} alt={garageCar.name}  />
	  <div className="text-center" style={{paddingTop: "1vh", fontSize: "3vh ", color: "white"}}>
	    <p className="text-left px-2" contenteditable="true"> Custom Name: {garageCar.nickName}</p>
        <p className="text-left px-2">{garageCar?.year} {garageCar?.manufacturer} {garageCar?.name}</p>
		<p className="text-left px-2">Transmission: {garageCar?.transmission}</p>
		<p className="text-left px-2"> Mileage: {garageCar?.mileage} </p>
		<p className="text-left px-2"> Spent: ${garageCar.price}.00  </p>
      </div>
	  {/* <div> Parts: {CarPartList(garageCar.id)} </div> */}
      

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
          		
				  <Button
				
					Dark
					color='Dark'
					className='me-2 btn-dark'
					onClick={(e) => {
						e.preventDefault();
						navigate(`/part-market/${garageCar.id}/`);
					}}
				>
					Parts
				</Button>
				<> </>
			<label for="sellCar"> Sell Price: </label>

			<input type="number" 
			id="sellCar" 
			name="sellCar" 
			placeholder='Enter $$'
			min="0" 
			max="9999999"
			onChange={handleChange} 
			value={inputPrice}
			/>
				<Button
				
				Dark
				color='Dark'
				className='SellButton'
				onClick={(e) => {
					e.preventDefault();
					console.log(inputPrice);

					if (inputPrice <= GCWorth) {
						console.log(user.money)
						user.money = user.money + parseInt(inputPrice)
						
						console.log("CAR SOLD");
						console.log(user.money);
						updateMoney(user);
						localStorage.setItem("user", JSON.stringify(user));
						

						alert(`you could have got $ ${GCWorth - inputPrice} more`);

						deleteGarageCar(garageCar.id);
						window.location.reload();
					} else { console.log("NOT SOLD") 
				alert('Asking price is too high, try a lower price...')}
				}}
			>
				Sell
			</Button>


			<Button id={`edit-garageCar--${garageCar.id}`} onClick={(e) => handleNavigate(e)}>
					Edit </Button>

			 
				</p><h2>Upgrades:</h2>
				
				<div class="list">
  
  <ul> 
	 {CarPartList(garageCar.id)} 
	  {/* {EditGarageCar(garageCar.id)} */}
	</ul>
   
 



</div>

<div>


</div>
			</CardFooter>
    </Card>
  );
};