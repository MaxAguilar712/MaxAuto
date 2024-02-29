import React from "react";
import { Card, CardImg, CardBody, CardFooter, Button } from "reactstrap";
import { Link } from "react-router-dom";
// import './Car.css';

export const GarageCar = ({ garageCar }) => {



	// const buyCar = () => {


	// 	console.log(car)
	// 	assertModuleDeclaration(car);
	// }





  return (
    <Card className='h-10' style={{margin: "1.5em", width:" 500px", height:"auto", background: "#727272"}}> 
	     <CardBody >      </CardBody>
      <CardImg className="Shadow" style={{margin: "2vh"}} top src={garageCar.imageUrl} alt={garageCar.name}  />
	  <div className="text-center" style={{paddingTop: "1vh", fontSize: "3vh ", color: "white"}}>
        <p className="text-left px-2">{garageCar?.year} {garageCar?.manufacturer} {garageCar?.name}</p>
		<p className="text-left px-2">Transmission: {garageCar?.transmission}</p>
		<p className="text-left px-2"> Mileage: {garageCar?.mileage} </p>
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
          		<strong> ${garageCar.price}.00  </strong>
				  <Button
				
					Dark
					color='Dark'
					className='me-2 btn-dark'
					onClick={(e) => {
						e.preventDefault();
						// navigate(`/Post/${post.id}/Comments`);
					}}
				>
					Parts
				</Button></p>
			</CardFooter>
    </Card>
  );
};