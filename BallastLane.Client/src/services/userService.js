import httpService from "../httpServices/httpService";

const getAllUsers = async () => {
    const result = await httpService.get("/users");
    return result;
}

export {
    getAllUsers
}