import { useEffect, useState } from 'react';
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";
const UserForm = ({ user, onSubmit }) => {

  const [userData, setUserData] = useState({
    id: 0,
    name: "",
    lastName: "",
    dateOfBirth: new Date(),
    address: "",
    phoneNumber: ""
  });

  useEffect(() => {
    if (user) {
      user.dateOfBirth = new Date(user.dateOfBirth)
      setUserData(user);
    }
  }, [user?.id])

  const handleOnChange = (event) => {
    setUserData({ ...userData, [event.target.name]: event.target.value })
  }

  return (
    <>
      <div className="mb-4">
        <label className='text-gray-800' htmlFor='name'>Name</label>
        <input
          type="text"
          name="name"
          id="name"
          value={userData?.name}
          className="mt-2 block w-full p-3 bg-gray-200"
          onChange={handleOnChange} />
      </div>

      <div className="mb-4">
        <label className='text-gray-800' htmlFor='lastName'>Last Name</label>
        <input
          type="text"
          name="lastName"
          id="lastName"
          value={userData?.lastName}
          onChange={handleOnChange}
          className="mt-2 block w-full p-3 bg-gray-200" />
      </div>
      <div className="mb-4">
        <label className='text-gray-800'>Date of Birth</label>
        <DatePicker showMonthDropdown showYearDropdown scrollableMonthYearDropdown scrollableYearDropdown yearDropdownItemNumber={100} className='mt-2 p-3 bg-gray-200' selected={userData?.dateOfBirth} onChange={(e) => { handleOnChange({ target: { name: "dateOfBirth", value: new Date(e) } }) }} name='dateOfBirth' />
      </div>

      <div className="mb-4">
        <label className='text-gray-800' htmlFor='phoneNumber'>Phone Number</label>
        <input type="text"
          name="phoneNumber"
          id="phoneNumber"
          value={userData?.phoneNumber}
          onChange={handleOnChange}
          className="mt-2 block w-full p-3 bg-gray-200" />
      </div>

      <div className="mb-4">
        <label className='text-gray-800' htmlFor='address'>Address</label>
        <input type="text"
          name="address"
          id="address"
          value={userData?.address}
          onChange={handleOnChange}
          className="mt-2 block w-full p-3 bg-gray-200" />
      </div>

      <div className='mb-4'>
        <button className="mt-5 w-full bg-blue-800 p-3 uppercase text-white text-lg rounded" onClick={() => { onSubmit(userData) }} >Submit</button>
      </div>

    </>
  )
}

export default UserForm