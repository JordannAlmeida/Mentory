import { check, sleep } from 'k6';
import http from 'k6/http';

export let options = {
  duration: '60s',
  vus: 100,
};

const payload = {
  creditCardNumber: 'string',
  creditCardAmoun: 0.0,
  validate: '2022-12-17T13:56:50.078Z',
  cvv: 'string',
  latitude: 0.0,
  longitude: 0.0,
  nameOwner: 'string',
  codeBank: 'string',
  paymentDate: '2022-12-17T13:56:50.078Z',
  creditCardLimit: 0,
};

const baseUrl = 'https://localhost:8082';
const endpoints = [
  '/payment/creditCard',
  '/payment/creditCardRPC',
];

const request = (endpoint) => {
  const response = http.post(`${baseUrl}${endpoint}`, payload);
  check(response, {
    'status is 200': (r) => r.status === 200,
  });
  return response.timings.duration;
};

export default function() {
  const result = {};
  endpoints.forEach((endpoint) => {
    result[endpoint] = request(endpoint);
  });
  return result;
}