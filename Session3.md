# Session 3

Based on [Publish vs Send](https://www.youtube.com/watch?v=byceLITKaIk&list=PLx8uyNNs1ri2MBx6BjPum5j9_MMdIfM9C&index=3)

# Performance

For performance measurement Chris Patterson tried using apachebench.
I will try this using hey because there is a snap-package available.
I installed this using `sudo snap install hey`.

## Excute performance test

`hey -m POST -A "application/octet-stream" 'https://localhost:5001/Order?id=8FD3475E-C226-4065-82F6-F36843F2D5E7&customerNumber=Hello%20123'`

## Result with 1 service

Summary:  
Total:	1.0626 secs  
Slowest:	0.6866 secs  
Fastest:	0.0418 secs  
Average:	0.2510 secs  
Requests/sec:	188.2143  

Details (average, fastest, slowest):  
DNS+dialup:	0.0307 secs, 0.0587 secs, 0.2889 secs  
DNS-lookup:	0.0013 secs, 0.0000 secs, 0.0168 secs  
req write:	0.0002 secs, 0.0000 secs, 0.0059 secs  
resp wait:	0.1075 secs, 0.0519 secs, 0.1711 secs  
resp read:	0.0001 secs, 0.0000 secs, 0.0042 secs  

## Result with 2 services

Summary:  
Total:	0.6195 secs  
Slowest:	0.3019 secs  
Fastest:	0.0434 secs  
Average:	0.1442 secs  
Requests/sec:	322.8189  

Details (average, fastest, slowest):  
DNS+dialup:	0.0243 secs, 0.0434 secs, 0.3019 secs  
DNS-lookup:	0.0009 secs, 0.0000 secs, 0.0102 secs  
req write:	0.0010 secs, 0.0000 secs, 0.0206 secs  
resp wait:	0.1184 secs, 0.0433 secs, 0.2232 secs  
resp read:	0.0005 secs, 0.0000 secs, 0.0303 secs  

## Publish

1. Add PUT action to controller and use `ISendEndpointProvider`
1. Change consumer to only return response when RequestId != null

### Performance

Run performance again:  
`hey -m PUT -A "application/octet-stream" 'https://localhost:5001/Order?id=8FD3475E-C226-4065-82F6-F36843F2D5E7&customerNumber=Hello%20123'
`

Summary:  
Total:	0.5047 secs  
Slowest:	0.3430 secs  
Fastest:	0.0113 secs  
Average:	0.1173 secs  
Requests/sec:	396.3018  


Details (average, fastest, slowest):  
DNS+dialup:	0.0457 secs, 0.0113 secs, 0.3430 secs  
DNS-lookup:	0.0014 secs, 0.0000 secs, 0.0145 secs  
req write:	0.0003 secs, 0.0000 secs, 0.0042 secs  
resp wait:	0.0659 secs, 0.0111 secs, 0.2498 secs  
resp read:	0.0001 secs, 0.0000 secs, 0.0004 secs  


