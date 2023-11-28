import { createBrowserRouter } from 'react-router-dom'
import UserList from "../components/UserList"
import Main from '../pages/Main';
import CreateUser from '../pages/User/CreateUser';

const router = createBrowserRouter(
    [
        {
            path: "/",
            element: <Main/>,
            children: [
                {
                    index: true,
                    element: <UserList/>
                },
                {
                    path:"user/create",
                    element:<CreateUser/>
                }
            ]
        }
    ]
)

export default router;
