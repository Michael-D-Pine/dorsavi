const HTTP_GET_SETTINGS = {
    headers: {
        'Cache-Control': 'no-cache',
        'Pragma': 'no-cache',
        'cache':'no-cache',
        'mode':'no-cors'
    }
}

const getJson = async (url) => {
    const response = await fetch(url, HTTP_GET_SETTINGS);
    return response.json();
}

const getOwners = async () => {
    const uri = `http://localhost:5800/api/getcats`

    return getJson(uri)
}


const getAddition = async (numberA, numberB) => {
    const uri = `http://localhost:5800/api/add/${numberA}/${numberB}`

    return getJson(uri)
}

export { getOwners, getAddition }