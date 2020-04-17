Stage 2
===

## New Features:

* **Adding support for reviews on movie.**
  
  <i>POST http://localhost:{port}/api/V1.0/movies/{movieId}/reviews</i>
  
  Return the movie and review.Body with customer needed for verification on creation.

* **Trivias can anonymously be sent for a movie.**

    <i>POST http://localhost:{port}/api/V1.0/movies/{movieId}/trivias</i>

    To make it a littlebit easier for development there will be no way to explicitly retrieve a Review or Trivia. These will come with a movie and can be handle from that object.

    Trivia is anonymously so no customer required. Only administrators should be able to remove these?!

    <i>DELETE http://localhost:{port}/api/V1.0/movies/{movieId}/trivias/{triviaId}</i>

    A Movie holds references to these Trivias and Reviews. The database should be configured to use foreing keys to accomondate these relationships (one to many, One movie holds many Reviews and Trivias). 

    To make this possible, make migrations and alter SQL generated before updating the database.

* **Introducing the RentService**

    <i>POST http://localhost:{port}/api/V1.0/rentservice/rent&format=json</i>

    To rent a product and recieve a reciept in json.
    When you make an purhase you will get a reciept in json by default but can be in xml if specified in the request with the format parameter: 
    
    XML: *[.../rent&format=xml]*<br>
    JSON: *[.../rent&format=json]* (Default when left out.)

    <i>POST http://localhost:{port}/api/V1.0/rentservice/</i>



## Seeding Reference Data:
---
Required reference data:

* Movie Categories

Controlling wether the data exists in the database and can't be removed during normal operations.