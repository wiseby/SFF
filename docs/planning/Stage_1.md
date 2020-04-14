Stage 1
===
EndPoint
---
Ändrar en film:
+ PUT https://x.x.x.x/api/movies/{id}

Lägga till en film:
+ POST https://x.x.x.x/api/movies/

Hämta alla filmer eller endast en:
+ GET https://x.x.x.x/api/movies/
+ GET https://x.x.x.x/api/movies/{id}

+ PUT https://x.x.x.x/api//{id}


+ GET https://x.x.x.x/api/studios/
+ GET https://x.x.x.x/api/studios/{id}
+ POST https://x.x.x.x/api/studios/
+ PUT https://x.x.x.x/api/studios/{id}
+ DELETE https://x.x.x.x/api/studios/{id}
Hyra ut en film till en studio:
+ POST https://x.x.x.x/api/movies/rent/ use tilde (~) for overriding [controller]


Entities
---
### Movie Model:
 
 * Id
 * Name
 * Duration
 * Category


### Studio Model:

 * Id
 * Name
 * Location
 * MoviesList
 * 

### MovieHandler


Requirements:
---

* A MovieHandler should hold a list of Movies
* MovieHandlers list of Movies should persist in data storage
* A Movie can be rented by a studio and be removed from MovieHandler
* MovieHandler holds reference to studios that rents a movie.
* A StudioHandler holds Studios.