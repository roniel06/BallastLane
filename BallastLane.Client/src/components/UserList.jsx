import { getAllUsers, remove } from "../services/userService";
import DataTable from 'react-data-table-component';
import { Link, useNavigate, Form, redirect, useLoaderData } from 'react-router-dom'

export async function action({params}){
    const result = await remove(params.userId);
    console.log(result);
    return redirect("/");
}

export async function loader(){
    const users = await getAllUsers();
    return users;
}

const UserTable = () => {

    const navigate = useNavigate();
    const users = useLoaderData();
    const columns = [
        {
            name: 'Id',
            selector: row => row.id,
            width: "80px"
        },
        {
            name: 'Name',
            selector: row => row.name,
        },
        {
            name: 'Last Name',
            selector: row => row.lastName,
        },
        {
            name: 'Phone Number',
            selector: row => row.phoneNumber,
        },
        {
            name: 'Date of Birth',
            selector: row => row.dateOfBirth,
        },
        {
            name: 'Address',
            selector: row => row.address,
        },
        {
            name: "Options",
            width: "250px",
            cell: row => (
                <>
                    <button className="bg-green-400 m-2 p-3 text-white text-sm rounded" onClick={() => navigate(`/user/${row.id}/notes`)}>Notes</button>
                    <button className="bg-orange-400 m-2 p-3 text-white text-sm rounded" onClick={() => navigate(`/user/edit/${row.id}`)}>Edit</button>
                    <Form
                        method='post'
                        action={`/user/delete/${row.id}`}
                        onSubmit={(e) => {
                            if (!confirm("Are you sure you want to delete this record?")) {
                                e.preventDefault()
                            }
                        }}>
                        <button className="bg-red-600 p-3 text-white text-sm rounded" type='submit'>Delete</button>
                    </Form>

                </>

            )
        }
    ];

    return (
        <>
        <div className="grid grid-cols-3">
            <p className="text-black text-lg">Welcome to the User Notes App</p>
        </div>
            <Link
                to={'/user/create'}
                className="bg-blue-500 text-white px-4 py-2 rounded float-right mb-5">
                Create User
            </Link>
            <DataTable
                columns={columns}
                data={users}
                pagination
                fixedHeader
                striped
                highlightOnHover
            />
        </>

    );
};

export default UserTable;
