import axios from "axios";

const CUSTOMER_API_BASE_URL = "http://localhost:5000/customer";

export const getCustomers = async () => {
    const response = await axios.get(CUSTOMER_API_BASE_URL);
    return response.data;
};

export const addCustomer = async (customer) => {
    const response = await axios.post(CUSTOMER_API_BASE_URL, customer);
    return response.data;
};

export const updateCustomer = async (id,customer) => {
    const response = await axios.put(`${CUSTOMER_API_BASE_URL}/${id}`, customer);
    return response.data;
};

export const deleteCustomer = async (customerId) => {
    const response = await axios.delete(`${CUSTOMER_API_BASE_URL}/${customerId}`);
    return response.data;
};