# CZ4001 Augmented Reality Assignment: The Shop

A contactless shopping experience powered by augmented reality. Only available for android users for now.

Click [here](https://www.youtube.com/watch?v=VygIYgySX1E) for demonstration video!

# Dev Notes:

### Unity IDE set up: 

- Unity Version: 2020.3.25f1 **(IMPORTANT)**

- Reset packages to default

- May encounter other errors, just google and search on unity forums

### Payment Gateway: Stripe

In order to create a sense of realism and practicality to our augmented reality shopping application, we planned and attempted to integrate a payment gateway to allow users to checkout and pay for their items. The payment gateway of choice was Stripe.

1. Methodology

    - As adviced by many unity developers in [unity forums](https://forum.unity.com/threads/integrate-stripe-with-unity.646399/), to implement a payment gateway and service in unity applications, it is wise to host the payment gateway on a separate webserver and later embed the webserver into unity (much like an `<iframe/>` or `<embed/>` tag in HTML).
    
    - We decided on hosting our payment gateway using a Node.js webserver and embedding it into our unity application using the [UniWebView](https://docs.uniwebview.com/) library.

2. Issue 1

    - UniWebView is only compatible on actual mobile devices or emulators (Android Studio/Xcode) and not Unity IDE emulator, making debugging extremely difficult
    
3. Issue 2

    - UniWebView can only embed websites that uses SSL to encrypt the HTTP traffic (i.e. HTTPS). Locally deploying our webserver and embedding it to our unity application will hence fail

    - Solution 1: Localhost deployment with SSL certificate as referenced [here](https://nodejs.org/en/knowledge/HTTP/servers/how-to-create-a-HTTPS-server/)

    - Solution 2: Cloud deployment on platforms with provided SSL certificate such as [heroku](https://devcenter.heroku.com/articles/ssl). This is the option we ended up going with and the live deployment of our payment gateway can be found [here](http://cz4001team1.herokuapp.com/)

4. Issue 3:

    - At the end of payment as part of our application flow, the UniWebView object should be destroyed and the appropriate scene should be loaded based on the status of the payment. However, there is no way for data to be communicated from the webserver to the unity application as UniWebView does not provide any functionality for this. As a result, just as a proof of concept, we first assume that all transactions will go through and are successful. Next, to simulate the destruction of the UniWebView object and the routing to the success screen, we use a coroutine and a timeout to automatically do this.

    - Possible solution for the closing of the UniWebView object: when the UniWebView object is created, create a button as well and link an `onclick` listener to the button which will destroy the UniWebView object on clicking the button as well as destroying itself. Clicking the button should also run the function for handling routing seen in the point below.

    - Possible solution for routing during payment: For each transaction, we can create a unique session ID. Based on the success of the transaction, we can create a record in firebase. After the UniWebView object is destroyed, our unity application can query the firebase database for this record in the firebase to see the status of the transaction. If it is successful then route it to the success page and if it is unsuccessful then route it to the checkout page to allow users to try checking out their items again.
