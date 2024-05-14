# Expense Sharing Application

An expense sharing application allows users to add expenses and split them among different people. The application maintains balances between users to track who owes how much to whom.

## Example

Suppose you live with 3 friends:

- You (User1, id: u1)
- Flatmates: User2 (u2), User3 (u3), User4 (u4)

### Electricity Bill

This month's electricity bill was Rs. 1000. You paid the entire amount, and now you want to split it equally among all flatmates.

Input: `u1 1000 4 u1 u2 u3 u4 EQUAL`

For this transaction, everyone owes Rs. 250 to User1:

- User2 owes Rs. 250 (0+250)
- User3 owes Rs. 250 (0+250)
- User4 owes Rs. 250 (0+250)

### Shopping on Flipkart

During a sale, you buy items for User2 and User3 using your card. The amounts for each person differ.

Input: `u1 1250 2 u2 u3 EXACT 370 880`

For this transaction:

- User2 owes Rs. 370 to User1
- User3 owes Rs. 880 to User1

The updated balances are:

- User2 owes Rs. 620 (250+370)
- User3 owes Rs. 1130 (250+880)
- User4 owes Rs. 250 (250+0)

### Outing with Flatmates

User4 pays for an outing, and everyone splits the bill equally. You owe for 2 people.

Input: `u4 1200 4 u1 u2 u3 u4 PERCENT 40 20 20 20`

For this transaction:

- User1 owes Rs. 480 to User4
- User2 owes Rs. 240 to User4
- User3 owes Rs. 240 to User4

The updated balances become:

- User1 owes Rs. 230 (250-480) to User4
- User2 owes Rs. 620 (620+0) to User1
- User2 owes Rs. 240 (0+240) to User4
- User3 owes Rs. 1130 (1130+0) to User1
- User3 owes Rs. 240 (0+240) to User4

## Requirements

- **User**: Each user should have a userId, name, email, and mobile number.
- **Expense**: Could be EQUAL, EXACT, or PERCENT.
- Users can add any amount, select any type of expense, and split with any other user.
- Percentages and amounts can have up to two decimal places.
- The application should verify if the sum of percentage shares is 100 in case of percent expenses.
- The application should verify if the sum of shares is equal to the total amount in case of exact expenses.
- Capability to show expenses for a single user as well as balances for everyone.
- Balances should be rounded off to two decimal places.

## Input

There are three types of input:

1. Expense format: `EXPENSE <user-id-of-payer> <no-of-users> <space-separated-list-of-users> <EQUAL/EXACT/PERCENT> <space-separated-values-in-case-of-non-equal>`
2. Show balances for all: `SHOW`
3. Show balances for a single user: `SHOW <user-id>`

## Output

When showing balances for a single user, display all balances that user is involved in. If there are no balances, print "No balances".

Format: `<user-id-of-x> owes <user-id-of-y>: <amount>`

## Optional Requirements

- Option to add an expense name, notes, images, etc.
- Option to split by share.
- Ability to show a passbook for a user.
- Option to simplify expenses.
