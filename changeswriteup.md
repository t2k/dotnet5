# Changes To KYC


* ID # is created on success of new customer.
* On success, "search" for customer and go right to the new view/page
  * ex : cust # 2575

* /kyc/accountpen/#id

* **double check** if "Co Name" field is even necessary.
* Consider extra "street" field.. as companies can have different locations.
* "City/State, City/Country" field should just be "State,Country"

* Hitting "Enter" fires event to move city data down into the "Legal Data" section. Could make this aysnc to update on the fly as top form is updated... 

## SAP Account Details

* Relatively useless..

* **"SAP Acct Only"** -> Should be a Yes or No option. 
  * This is the only thing from **Account Details** that is necessary. Consider moving this to a better place. Less clutter.
* Perhaps consider changes "Legal Entity" to something else. (Not sure if necessary)

* Consider an option to give details about Management itself.
* "Substiture of Publicly traded""
  * This will give more info about management.

* Can get rid of "Unrated - Included" (for funds!) field.

* "Existing DZ Relationship" check box **has** to be checked, even when the customer isn't an "existing" customer. 
  * Add a "new customer" check box, that works the same.

* "Customer Notification check bx" -> consider getting rid of completely..

* Check how "Regulation GG" checkbox is wired up. Seems a bit odd.. (could be hard coded..)

## CIP Add Contact

* All form data **shouldn't** have to be filled out completely just in order for the process to save. You should be able to save a record on the fly, then go back up to it to update it completely.

## Risk Report

* In area 4, "bad press/GG" is in every field. 
  * This has to do with the fact that it is probably hard coded. Take a look into cleaning this up.

## Printing

* **Primary Address** -> **Mailing Address**

* Reference for a telephone number. Put "compliance" in front of it.
  * Account manager can send to a specific 

* **Add sorting for "less than 90 days"**
  * Sort by "Name" & "Review Type"
  
## Risk Rating

* "Calculate" should calculate the rating, and ask to save changes right away
  * she can forget to hit save after calculate... just move functionality into other button call.

## CIP (more)

* When you make a change, for reporting, add some sort of dropdown list for "standardized comments"
* Risk rating comments should have reasons for **why**

* Perhaps add a **comment** box at the bottom of the risk rating view.

## Financial Institutes (Nora)

* Consider some sort of version control for viewing pdf files. 
* They want a way to go back and look at past versions of pdfs.

* Add **"last reviewed**" field on account manager.



