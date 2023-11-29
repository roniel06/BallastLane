import React from 'react'
import { Outlet } from 'react-router-dom'

const Main = () => {
    return (
        <>
            <div className="min-h-full">
                <nav className="bg-gray-800">
                    <div className="mx-auto max-w-7xl px-4 sm:px-6 lg:px-8">
                        <div className="flex h-16 items-center justify-between">
                            <div className="flex items-center">
                                <div className="flex-shrink-0">
                                    <h2 className='text-white text-lg'>BallastLane</h2>
                                </div>

                            </div>
                        </div>
                    </div>
                </nav>
            </div>
            <main>
                <div className='mt-5 m-8'>
                    <Outlet />
                </div>
            </main>


        </>
    )
}

export default Main