const config = {
    'development': {
        endpoint: 'https://localhost:5000/api'
    }
}

export default config[process.env.NODE_ENV];