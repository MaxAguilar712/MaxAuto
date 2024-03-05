import React, { useState } from "react";
import { Card, CardImg, CardBody, CardFooter, Button } from "reactstrap";
import { Links, useNavigate } from "react-router-dom";
// import './Car.css';

export const GarageCar = ({ garageCar }) => {

	const [inputPrice, setInputPrice] = useState("");

	const GCWorth = garageCar.worth;

	const handleChange = (e) => {
		setInputPrice(e.target.value);
	  }
	const navigate = useNavigate();
	// const goToPartPage = () => {

		
	// 	 navigate('/part-market');
	// 	window.location.reload();

	// }



	// const buyCar = () => {


	// 	console.log(car)
	// 	assertModuleDeclaration(car);
	// }





  return (
    <Card className='h-10' style={{margin: "1.5em", width:" 375px", height:"auto", background: "#727272"}}> 
	     <CardBody >      </CardBody>
      <CardImg className="Shadow" style={{margin: "2vh"}} top src={garageCar.imageUrl} alt={garageCar.name}  />
	  <div className="text-center" style={{paddingTop: "1vh", fontSize: "3vh ", color: "white"}}>
        <p className="text-left px-2">{garageCar?.year} {garageCar?.manufacturer} {garageCar?.name}</p>
		<p className="text-left px-2">Transmission: {garageCar?.transmission}</p>
		<p className="text-left px-2"> Mileage: {garageCar?.mileage} </p>
		<p className="text-left px-2"> Spent: ${garageCar.price}.00  </p>
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
						console.log("CAR SOLD")
					} else { console.log("NOT SOLD") }
				}}
			>
				Sell
			</Button>
				</p>

			</CardFooter>
    </Card>
  );
};