import { createBrowserRouter } from 'react-router-dom'
import UserList from "../components/UserList"
import Main from '../pages/Main';
import CreateUser from '../pages/User/CreateUser';
import EditUser, { loader as editUserLoader } from '../pages/User/EditUser';
import { action as deleteUserAction, loader as getAllUsersLoader } from "../components/UserList"
import { loader as getUserNotesLoader } from "../pages/User/UserNotes"
import UserNotes from '../pages/User/UserNotes';
import CreateNote, { loader as getUserLoader } from '../pages/Notes/CreateNote';
import EditNote, {loader as editNotesLoader} from "../pages/Notes/EditNote"

const router = createBrowserRouter(
    [
        {
            path: "/",
            element: <Main />,
            children: [
                {
                    index: true,
                    element: <UserList />,
                    loader: getAllUsersLoader
                },
                {
                    path: "user/create",
                    element: <CreateUser />
                },
                {
                    path: "user/edit/:userId",
                    element: <EditUser />,
                    loader: editUserLoader
                },
                {
                    path: "user/delete/:userId",
                    action: deleteUserAction
                },
                {
                    path: "user/:userId/notes",
                    element: <UserNotes />,
                    loader: getUserNotesLoader
                },
                {
                    path: "notes/:userId/create",
                    element: <CreateNote />,
                    loader: getUserLoader
                },
                {
                    path: "notes/:noteId/edit",
                    element: <EditNote />,
                    loader: editNotesLoader
                }
            ]
        }
    ]
)

export default router;
