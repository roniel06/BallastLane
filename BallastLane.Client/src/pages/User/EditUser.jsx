import { useLoaderData, useNavigate } from "react-router-dom";
import Error from "../../components/Error";
import UserForm from "../../components/UserForm";
import { getbyId, update } from "../../services/userService";
import { useState } from "react";


export async function loader({ params }) {
    const user = await getbyId(params.userId);
    if (Object.values(user).length === 0) {
        throw new Response("", {
            status: 204,
            statusText: "User Not Found"
        });
    }
    return user;
}

const EditUser = () => {
    const navigate = useNavigate();
    const [errors, setErrors] = useState([]);

    async function action(data) {

        if (Object.values(data).includes('')) {
            setErrors([...errors, ["You should Fill all the fields"]]);
            setTimeout(() => {
                setErrors([])
            }, 2000)
            return;
        }
        const result = await update(data.id, data)
        return navigate("/");
    }
    const user = useLoaderData();
    return (
        <>
            <h1 className="font-black text-4xl text-blue-900">Update User</h1>
            <div className="flex justify-end">
                <button
                    onClick={() => navigate("/")}
                    className="bg-orange-600 text-white px-3 py-1 font-bold uppercase rounded">Go back</button>
            </div>

            {errors?.length && errors.map((error, i) => <Error key={i}>{error}</Error>)}
            <UserForm user={user} onSubmit={action} />

        </>
    )
}

export default EditUser