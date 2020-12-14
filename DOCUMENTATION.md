# SpookVooper.Api Documentation
## Routes
### User
| Route | Parameter(s) : Type | Return Value : Type |
| --- | --- | --- |
| /GetUser | SVID : string | user data : dict |
| /GetUsername | SVID : string | username : string |
| /GetSVIDFromUsername | username : string | SVID : string |
| /GetUsernameFromDiscord | Discord ID : ulong | username : string |
| /GetSVIDFromDiscord | Discord ID : ulong | SVID : string |
| /GetUsernameFromMinecraft |  Minecraft ID : string | username : string |
| /GetSVIDFromMinecraft | Minecraft ID : string | SVID : string |
| /HasDiscordRole | Discord ID : ulong <br> Discord Role Name : string | bool |
| /GetDiscordRoles | SVID : string | Discord roles : list\<dict> |
| /GetDaysSinceLastMove | SVID : string | days since last move : int |
| /GetSenators | | senator data : list\<dict> |

### Group
| Route | Parameter(s) : Type | Return Value : Type |
| --- | --- | --- |
| /DoesGroupExist | SVID : string | bool |
| /GetGroupMembers | SVID : string | all members' SVID : list |
| /HasGroupPermission | SVID : string <br> user SVID : string <br> permission : string | bool |
| /GetSVIDFromName | name : string | SVID : string |
| /GetName | SVID : string | name : string |

### Eco
| Route | Parameter(s) : Type | Return Value : Type |
| --- | --- | --- |
| /GetBalance | SVID : string | balance : decimal |
| /SendTransactionByIDs | from (SVID) : string <br> to (SVID) : string <br> amount : decimal <br> auth : string <br> detail : string | result : string
| /GetStockValue | ticker : string | stock value : decimal |
| /GetStockHistory | ticker : string <br> type : string <br> count : int <br> interval : int <br> | stock history : list |
| /SubmitStockBuy | ticker : string <br> count : int <br> price : decimal <br> account ID (SVID) : string <br> auth : string | result : string |
| /SubmitStockSell | ticker : string <br> count : int <br> price : decimal <br> account ID (SVID) : string <br> auth : string | result : string |
| /CancelOrder | orderid : int <br> account ID (SVID) : string <br> auth : string | result : string |
| /GetStockBuyPrice | ticker : string | cheapest stock available : decimal |
| /GetQueueInfo | ticker : string <br> type : string | queue data : list\<dict> |
| /GetUserStockOffers | ticker : string <br> SVID : string | stock offer data : list\<dict> |
| /GetDistrictWealth | ID (district name) : string | total wealth : decimal |
| /GetDistrictUserWealth | ID (district name) : string | total user wealth : decimal |
| /GetDistrictGroupWealth | ID (district name) : string | total group wealth : decimal |
| /GetOwnerData | ticker : string | ownership data : list\<dict> |
