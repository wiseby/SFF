Stage 1
===
EndPoints
---
Ändrar en film:
+ PUT https://x.x.x.x/api/V1.0/movies/{id}

Lägga till en film:
+ POST https://x.x.x.x/api/V1.0/movies/

Hämta alla filmer eller endast en:
+ GET https://x.x.x.x/api/V1.0/movies/
+ GET https://x.x.x.x/api/V1.0/movies/{id}

Hämta alla studios som finns registrerade även hämta endast en:
+ GET https://x.x.x.x/api/V1.0/studios/
+ GET https://x.x.x.x/api/V1.0/studios/{id}

Ändra information av en studio:
+ PUT https://x.x.x.x/api/V1.0/studios/{id}

Skapa och ta bort studio:
+ POST https://x.x.x.x/api/V1.0/studios/
+ DELETE https://x.x.x.x/api/V1.0/studios/{id}

Hyra ut en film till en studio:
+ POST https://x.x.x.x/api/V1.0/movies/rent/ use tilde (~) for overriding [controller]

### **Trivia:**
The Trivia is not suposed to hold a reference to a Studio (according to IMDB).
A Trivia is more of a Generic comment to a movie. 
Instead I'm introcucing a Review that contains information:

* **Rating** (0.1 - 10 stars)
* **Comment** in form of a paragraph of text that sums up the overall experience of the movie.
* Reference to a **Studio** that can justify the content of the review.



Entities
---
### Movie Model:
 
 * Id
 * Name
 * Duration
 * Category

 Requirments:
 


### Studio Model:

 * Id
 * Name
 * Location
 * MoviesList

### Trivia Model:

* Id
* MovieId
* TextContent
* Likes
* CreateDate

### Review Model:

* Id
* MovieId
* StudioId
* Rating
* Comment

Requirements:

### RentService:
---

* A RentService should hold a list of Movies
* RentService list of Movies should persist in data storage.
* A Movie can be rented by a studio and be removed from RentService.
* MovieHandler holds reference to studios that rents a movie.

### MovieHandler:

* Should keep track of items beeing rented so not more than maximum number of copies beeing rented out exceed's number of licenses.
* Can create a new Movie.

### StudioHandler:

* Studio Name should not be null or empty.
* Studio Location should have a lication.
* Can create a Studio and make it persistant.
* Can remove a studio.
* Can make changes to studio Name and Location.

## Movie

* Title should not be null or empty.
* Duration should be longer than zero.