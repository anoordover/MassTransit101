# Session 4

Based on [MassTransit State Machine Sagas using Automatonymous](https://www.youtube.com/watch?v=2bPumhSTigw&list=PLx8uyNNs1ri2MBx6BjPum5j9_MMdIfM9C&index=4)

## Introduction Saga's

In Session 4 Chris Patterson implemented a base Saga (OrderStateMachine).
In this Saga he also implemented an event to ask for the state of the Order.
At first my solution for getting the status of the order didn't work correctly.
Response to my status-request appeared on a "skipped" queue.
The reason for this was the mistake I made at first in getting the response of the state of the order in the controller.

```
var status = await _checkOrderClient.GetResponse<CheckOrder>(new
            {
                OrderId = id
            });
```

this code should have been
```
var status = await _checkOrderClient.GetResponse<OrderStatus>(new
            {
                OrderId = id
            });

```
