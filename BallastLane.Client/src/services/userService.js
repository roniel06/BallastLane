import httpService from "../httpServices/httpService";

const getAllUsers = async () => {
    const result = await httpService.get("/users");
    return result;
}

const create = async (user) => {
    const result = await httpService.post("/users", user);
    console.log(result)
    return result;
}

const getbyId = async (userId) => {
    const result = await httpService.get(`/users/${userId}`)
    console.log(result)
    return result;
}

const update = async (userId, user) => {
    user.id = userId;
    const result = await httpService.put("/users", user);
    console.log(result);
    return result;
}

const remove = async (userId) => {
    const result = await httpService.delete(`/users/${userId}`);
    console.log("Detele Operation: ", result);
    return result;
}

const getUserWithNotes = async (userId)=>{
    const result = await httpService.get(`/users/GetUserWithNotes/${userId}`);
    console.log(result);
    return result;
}

export {
    getAllUsers,
    create,
    getbyId,
    update,
    remove,
    getUserWithNotes
}