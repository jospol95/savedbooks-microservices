import http from '../http-common'
import IBook from '../types/Book'

const getAll = () => {
    return http.get<Array<IBook>>('/books');
}

const BookService = {
    getAll,
}

export default BookService
