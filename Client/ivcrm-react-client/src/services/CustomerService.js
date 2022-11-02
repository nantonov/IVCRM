import axios from "axios";

export default class PostService {
    static async getById(id) {
        const response = await axios.get('https://localhost:7159/api/customer/' + id)
        return response.data;
    }
}
 