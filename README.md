# CashFlowin
I have found that besides Net Worth, Budgets, and Bookeeping that Cash Flow is one of the most important aspects of managing my finances.

For years I used an Excel Spreadsheet (in root of project), with a bunch of super formulas. I could set Weekly, Bi-Weekly and Monthly Expenses and extrapolate where my cash position would be in the future.

I figured I would try to emulate this in a website, using .Net Core and React.

I will be hosting this site on Azure and using Azure DevOps to manage Sprints and Deployment Pipelines, and containerize using Kubernetes.


Main Features Are:

Upon entering a starting amount, and setting up my recurring charges, I should end up with a number stating where my cash position will be at any date:

StartValue -> Date -> ValueOnDate



I should have a function to tell me where in the future I will be under a certain threshold:

StartValue -> Date -> Threshold -> [DatesUnderThreshold]



Another function would be to find a date in the future where I would have a certain amount, and never go under it again. Example, if I would like to buy a car for $5000,
when in the future will I have $5000 and never go under $0 after that:

StartValue -> ExpenseAmount -> Date



Lastly, I should be able to create a spreadsheet dynamically and download:

StartValue -> EndDate -> Spreadsheet



I hope this helps someone else manage their finances :)
