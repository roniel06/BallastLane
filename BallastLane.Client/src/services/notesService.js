import httpService from "../httpServices/httpService";

const getById = async (noteId) =>{
    const result = await httpService.get(`/notes/${noteId}`);
    console.log(result)
    return result;
}
const create = async (note) =>{
    const result = await httpService.post("/notes", note);
    console.log(result)
    return result;
}

const update = async (note) =>{
    const result = await httpService.put("/notes", note);
    console.log(result)
    return result;
}

const remove = async (noteId) =>{
    const result = await httpService.delete(`/notes/${noteId}`);
    console.log(result)
    return result;
}

export {
    getById,
    create,
    update,
    remove
}

