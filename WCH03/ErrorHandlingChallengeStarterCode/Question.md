# Error Handling Challenge
## Goal
	Stop the errors! If an exception occurs in the 
	MakePayment method, catch it and print 
	“Payment skipped for payment with 4 items” 
	(or whatever the number is). 
	However, the method properly returns a null one time.
	Fix that error (don’t just catch it) and print 
	“Null value for item 4” instead.
## Bonus
	Handle the different errors differently. 
	If you get an IndexOutOfRange exception, 
	print “Skipped invalid record”. 
	If it is a FormatException and the number of items 
	is not 5, print “Formatting Issue”. 
	For everything else, print the standard error.
	If an exception has an InnerException, 
	print the Message of the InnerException
	at the end of whatever message is being displayed.