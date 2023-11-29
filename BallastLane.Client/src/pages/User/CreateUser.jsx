import UserForm from "../../components/UserForm"
import { useNavigate } from "react-router-dom"
import Error from "../../components/Error";
import { create } from "../../services/userService"
import { useState } from "react";


const CreateUser = () => {
  const navigate = useNavigate();
  const [errors, setErrors] = useState([]);

  async function action(request) {

    if (Object.values(request).includes('')) {
      setErrors([...errors, ["You should Fill all the fields"]]);
      setTimeout(() => {
        setErrors([])
      }, 2000)
      return;
    }
    const result = await create(request);
    if (result) {
      return navigate("/")
    }
    return;
  }

  return (
    <>
      <h1 className="font-black text-4xl text-blue-600">New User</h1>
      <p className="mt-3">Please fill up all the fields</p>
      <div className="flex justify-end">
        <button
          onClick={() => navigate("/")}
          className="bg-orange-600 text-white px-3 py-1 font-bold uppercase rounded">Go back</button>
      </div>

      {errors?.length && errors.map((error, i) => <Error key={i}>{error}</Error>)}

      <UserForm onSubmit={action} />
    </>

  )
}

export default CreateUser