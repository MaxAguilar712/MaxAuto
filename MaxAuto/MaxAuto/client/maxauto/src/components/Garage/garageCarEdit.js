import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import {
	Button,
	Container,
	Input,
	InputGroup,
	InputGroupText,
} from "reactstrap";
import { getGarageCarById, updateGarageCar } from "../../APIManagers/GarageManager";

export const EditGarageCar = () => {
	const { id } = useParams();
	const [garageCar, setGarageCar] = useState({
		id: id, 
		nickName: "",
	});
	const navigate = useNavigate();
	const handleUpdate = (e) => {
		e.preventDefault();
		const copy = { ...garageCar };
		updateGarageCar(copy).then((res) => navigate("/my-garage"));
	};
	useEffect(() => {
		getGarageCarById(id).then((res) => setGarageCar(res));
	}, [id]);
	return (
		<Container>
			<InputGroup>
				<InputGroupText></InputGroupText>
				<Input
					placeholder='NickName'
					value={garageCar.nickName}
					onChange={(e) => {
						const copy = { ...garageCar };
						copy.nickName = e.target.value;
						setGarageCar(copy);
					}}
				/>
			</InputGroup>
			<Button color='primary' onClick={(e) => handleUpdate(e)}>
				Save
			</Button>
			<Button
				outline
				onClick={(e) => {
					e.preventDefault();
					navigate("/my-garage");
				}}
			>
				Cancel
			</Button>
		</Container>
	);
};