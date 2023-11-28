import React from 'react'
import { Outlet, Link, useLocation } from 'react-router-dom'

const Main = () => {
    const location = useLocation();
    return (
        <div className="container mx-auto p-4">
            <h1 className="text-3xl font-bold mb-4">Users and Notes App</h1>
            <Link
                to={'/user/create'}
                className="bg-blue-500 text-white px-4 py-2 rounded float-right mb-5">
                Create User
            </Link>

            <div className='mt-5'>
                <Outlet />
            </div>

        </div>
    )
}

export default Main