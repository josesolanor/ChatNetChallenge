# Chat .Net Challenge

_Author: Jose G Solano Romero_

* Chat.Presentacion.API - Asp.net API Core 3.1
* Chat.Presentacion.StockBot - Asp.net API Core 3.1
* Chat.Presentacion.Client - Asp.net MVC Core 3.1
* Chat.Domain - Library class Core 3.1
* Chat.Infraestruture - Library class Core 3.1
* Chat.Application  - Library class 3.1
* TestAPIWithDB - XUnit
* TestIntegrationAPI - MSUnit
* TestIntegrationStockBot - MSUnit

## Mandatory Features
* Allow registered users to log in and talk with other users in a chatroom.
* Allow users to post messages as commands into the chatroom with the following format /stock=stock_code
* Create a decoupled bot that will call an API using the stock_code as a parameter ( https://stooq.com/q/l/?s=aapl.us&f=sd2t2ohlcv&h&e=csv , here aapl.us is the stock_code )
* The bot should parse the received CSV file and then it should send a message back into the chatroom using a message broker like RabbitMQ. The message will be a stock quote using the following format: “APPL.US quote is $93.42 per share”. The post owner will be the bot.
* Have the chat messages ordered by their timestamps and show only the last 50 messages.
* Unit test the functionality you prefer.

## Bonus
* Use .NET identity for users authentication (made a custom one with .NET identity)
* Handle messages that are not understood or any exceptions raised within the bot.

## Run API's and Client 🚀

### Use Visual Studio 2019 or above
To make it work locally all projects must configure the VS to raise multiple services.

Go to Solution > Properties > Expand the Common Properties node, and choose Startup Project.
Choose the Multiple Startup Projects option and set start on:

* Chat.Presentacion.API,
* Chat.Presentacion.StockBot 
* Chat.Presentacion.Client

Press Start and a new browser will appear with the Login Page.
