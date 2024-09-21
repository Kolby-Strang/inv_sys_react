export const dev = window.location.origin.includes('localhost')
export const baseURL = dev ? 'https://localhost:7045' : ''
export const useSockets = false
export const domain = 'strangkolby.us.auth0.com'
export const clientId = 'eRyKTI5HCdDh7BqM0hj63QD4UMQ2wU7X'
export const audience = 'https://kolbystrangauth.com'