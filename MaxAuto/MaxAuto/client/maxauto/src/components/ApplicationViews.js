import React from "react";
import { Route, Routes } from "react-router-dom";
import Hello from "./Hello";



// import { CarList } from "./Cars/CarList";
// import { Car } from "./Cars/Car";
import { CarList} from "./Cars/CarList";
import { PartList} from "./Parts/PartList";
import { GarageCarList } from "./Garage/Garage";
// import { TagList } from "./tags/TagList.js";
// import { AddTag } from "./tags/AddTag.js";
// import { DeleteTag } from "./tags/DeleteTag.js";
// import { AddCategory } from "./categories/CategoryForm.js";
// import { CategoryList } from "./categories/CategoryList.js";
// import { EditCategory } from "./categories/EditCategory.js";
// import { DeleteCategory } from "./categories/DeleteCategory.js";
// import PostList from "./Posts/PostList.js";
// import PostDetails from "./Posts/PostDetails.js";
// import { PostForm } from "./Posts/PostForm.js";
// import { EditTag } from "./tags/EditTag.js";
// import UserProfileList from "./UserProfile/UserProfileList";
// import { CommentList } from "./comments/CommentList.js";
// import UserProfile from "./UserProfile/UserProfile.js";
// import { AddComment } from "./comments/AddComment.js";
// import { DeleteComment } from "./comments/DeleteComment.js";
// import { EditComment } from "./comments/EditComment.js";
// import { CommentDetails } from "./comments/CommentDetails.js";
// import { PostTagsContainer } from "./postTags/PostTagsContainer.js";
// import { DeactivateUser } from "./UserProfile/DeactivateUser.js";
// import { ReactivateUser } from "./UserProfile/ReactivateUser.js";
// import { PostContainer } from "./Posts/PostContainer.js";
// import { UserPosts } from "./Posts/UserPosts.js";

export default function ApplicationViews({ isLoggedIn }) {
	const user = JSON.parse(localStorage.getItem("user"));
	return (
		<Routes>
			<Route path='/' element={<Hello />} />
			<Route path='/car-market' element={<CarList />} />
			{/* <Route path='/part-market'  /> */}
			<Route path='/part-market/:id' element={<PartList />}/>
			<Route path='/my-garage' element={<GarageCarList/>} />
			{/* <Route path='/part-market' element={<PartMarket />} />
			<Route path='/my-garage' element={<MyGarage />} /> */}
			{/* <Route path='/Tags/Edit/:id' element={<EditTag />} /> */}
			{/* <Route path='/post' element={<PostContainer />} />
			<Route path="/post/:id" element={<PostDetails />} />
			<Route path="/postForm/" element={<PostForm />} />
			<Route path="/my-posts" element={<UserPosts /> } />
			<Route path='/Categories' element={<CategoryList />} />
      		<Route path="/categories/form" element={<AddCategory />} />
			<Route path='/Post/:postId/Comments' element={<CommentList />} />
			<Route path='/Post/:postId/Comments/Add' element={<AddComment />} />
			<Route path='/Categories' element={<CategoryList />} />
			<Route path='/Categories/Edit/:id' element={<EditCategory />} />
			<Route path='/Categories/Delete/:id' element={<DeleteCategory />} /> */}
      {/* <	Route path="/categories/form" element={<AddCategory />} />
			<Route
				path='/Post/:postId/Comments/Delete/:commentId'
				element={<DeleteComment />}
			/>
			<Route
				path='/Post/:postId/Comments/Edit/:commentId'
				element={<EditComment />}
			/>
			<Route
				path='/Post/:postId/Comments/:commentId'
				element={<CommentDetails />}
			/>
			{user && user.userTypeId == 1 ? (
				<>
					<Route path='/UserProfiles' element={<UserProfileList />} />
					<Route
						path='/UserProfiles/:userId/Deactivate'
						element={<DeactivateUser />}
					/>
					<Route
						path='/UserProfiles/:userId/Reactivate'
						element={<ReactivateUser />}
					/>
				</>
			) : (
				""
				)} */}
{/* 
			{ user && user.userTypeId == 1? <Route path="/UserProfiles/:id" element={<UserProfile />} />:""}
			<Route path='/Post/:postId/Tags' element={<PostTagsContainer />} /> */}
		</Routes>
	);
}