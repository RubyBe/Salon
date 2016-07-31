# _Salon Management Program with C#, Nancy, Razor, and SQL Databases_

#### _Project Specifications_

#### By _**Sid Benavente**_

## Description/Specs

A program which allows management of salon Stylists and their associated Clients.

* Program Routing

| Method       | Route           | Action  | Model/Comments |
| ------------- |:-------------:| -----:| -----:|
| GET| /| Returns index.cshtml, Model| Model is a list of all Stylist instances |
| POST| /| Returns index.cshtml, Model| Model is a list of all Stylist instances, after saving a new stylist |
| GET|/stylists/{id}| Returns stylist.cshtml, Model | Model is a dictionary containing the selected Stylist instance, and all associated Client instances |
| GET| /stylist/edit/{id}| Returns stylist_edit.cshtml, Model| Model is a found Stylist instance to be updated |
| PATCH| /stylist/edit/{id}| Returns success.cshtml| Updates Stylist information, routes to simple confirmation page with link to home page |
| POST| /stylist/new| Returns success.cshtml | Creates and saves a new stylist, routes to simple confirmation page with link to home page |
| GET| /stylist/delete/{id}| Returns stylist_delete.cshtml, Model| Model is a found Stylist instance to be deleted, along with all associated clients |
| DELETE| /stylist/delete/{id}| Returns success.cshtml| Deletes a single Stylist instance, routes to simple confirmation page with link to home page |


## Use this program
Clone this repository. Prepare your machine to run the Kestrel server by following the [instructions here.](https://www.learnhowtoprogram.com/c/getting-started-with-c/installing-c)
To start the local server, type in "DNX Kestrel" at the same prompt. Navigate in your browser to "LocalHost:5004" to view the homepage.

## Known Bugs

## Support and contact details
Please contact the authors if you have any questions or comments.

## Technologies Used
This web application was created using C#, Nancy, Razor, SQL, CSS, and Bootstrap.

### License
Copyright (c) 2016 _**Sid Benavente**_

This software is licensed under the MIT license.
