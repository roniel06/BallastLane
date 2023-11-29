import React from 'react'
import { Outlet, useLocation } from 'react-router-dom'

const Main = () => {
    const location = useLocation();
    return (
        <div className="container mx-auto p-4">
            <h1 className="text-3xl font-bold mb-4">Users and Notes App</h1>
            <div className='mt-5'>
                <Outlet />
            </div>

        </div>
    )
}

export default Main