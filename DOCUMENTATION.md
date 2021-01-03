# SpookVooper.Api Documentation
## api.spookvooper.com (as of 1/1/2021)
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

## SpookVooper.Api (as of v1.3.16)
### SpookVooperAPI
| Name | Paramaters(s) : Type | Return Value : Type |
| --- | --- | --- |
| GetData | url : string | data : string |

#### Economy
| Name | Paramaters(s) : Type | Return Value : Type |
| --- | --- | --- |
| CancelOrder | orderid : string <br> accountid : string <br> auth : string | result : TaskResult |
| GetQueueInfo | ticker : string <br> type : string | queue info : list\<OfferInfo> |
| GetStockBuyPrice | ticker : string | buy price : decimal |
| GetStockHistory | ticker : string <br> type : string <br> count : int <br> interval : int | buy price history : list\<decimal> |
| GetStockValue | ticker : string | value : decimal |
| GetStockVolumeHistory | ticker : string <br> type : string <br> count : int <br> interval : int | volume history : list\<decimal> |
| GetUserStockOffers | ticker : string <br> svid : string | stock offers : list\<StockOffer> |
| SendTransactionByIDs | from : string <br> to : string <br> amount : decimal <br> auth : string <br> detail : string | result : TaskResult |
| SubmitStockBuy | ticker : string <br> count : int <br> price : decimal <br> accountid : string <br> auth : string | result : TaskResult |
| SubmitStockSell | ticker : string <br> count : int <br> price : decimal <br> accountid : string <br> auth : string | result : TaskResult |

### TaskResult
| Name | Type | Value |
| --- | --- | --- |
| Info | string |
| Succeeded | bool |

| Name | Paramaters(s) : Type | Return Value : Type |
| --- | --- | --- |
| TaskResult | success : bool <br> info : string |

### Economy
#### ApplicableTax
| Name | Type | Value |
| --- | --- | --- |
| CapitalGains | 3 | int |
| Corporate | 1 | int |
| None | 0 | int |
| Payroll | 2 | int |
| Sales | 4 | int |

##### Stocks
##### OfferInfo
| Name | Type | Value |
| --- | --- | --- |
| Amount | int |
| Target | decimal |

##### StockDefinition
| Name | Type | Value |
| --- | --- | --- |
| Current_Value | decimal |
| Group_Id | string |
| Ticker | string |

##### StockObject
| Name | Type | Value |
| --- | --- | --- |
| Amount | int |
| Id | string |
| Name | string |
| Owner_Id | decimal |
| Ticker | string |

| Name | Paramaters(s) : Type | Return Value : Type |
| --- | --- | --- |
| GetValue | | decimal |
| IsOwner | entity : Entity | bool |

##### StockOffer
| Name | Type | Value |
| --- | --- | --- |
| Amount | int |
| Id | string |
| OrderType | string |
| Owner_Name | string |
| Owner_Id | string |
| Target | decimal
| Ticker | string |

##### StockTradeModel
| Name | Type | Value |
| --- | --- | --- |
| Amount | int |
| Buy_Id | string |
| From | string |
| Price | decimal |
| Sell_Id | string
| Ticker | string |
| True_Price | decimal |
| To | string |

##### ValueHistory
| Name | Type | Value |
| --- | --- | --- |
| Account_Id | string |
| Id | string |
| Time | DateTime |
| Type | string |
| Value | decimal |
| Volume | int |

#### Transaction
| Name | Type | Value |
| --- | --- | --- |
| Amount | decimal |
| Detail | string |
| Force | bool |
| FromAccount | string |
| Tax | ApplicableTax |
| ToAccount | string |

| Name | Paramaters(s) : Type | Return Value : Type |
| --- | --- | --- |
| GetReciever | | receiver : Entity |
| GetSender | | sender : Entity |
| Transaction | | |

#### TransactionAction
| Name | Paramaters(s) : Type | Return Value : Type |
| --- | --- | --- |
| TransactionAction | transaction : Transaction | |

#### TransactionHub
| Name | Type | Value |
| --- | --- | --- |
| connection | HubConnection |
| OnTransaction | TransactionAction |

| Name | Paramaters(s) : Type | Return Value : Type |
| --- | --- | --- |
| TransactionHub | | |
| OnClosed | e : Exception | |

### Entities
#### DiscordRoleData
| Name | Type | Value |
| --- | --- | --- |
| Id | ulong |
| Name | string |

#### Entity
| Name | Type | Value |
| --- | --- | --- |
| Id | string |
| Auth_Key | string |

| Name | Paramaters(s) : Type | Return Value : Type |
| --- | --- | --- |
| Entity | svid : string <br> auth_key : string | |
| GetBalance | | balance : decimal |
| GetName | | name : string |
| SendCredits | amount : decimal <br> to : string <br> description : string | result : TaskResult |
| SendCredits | amount : decimal <br> to : Entity <br> description : string | result : TaskResult |

#### EntitySnapshot
| Name | Type | Value |
| --- | --- | --- |
| Credits | decimal |
| Id | string |
| Image_Url | string |
| Name | string |

#### Groups
##### Group
| Name | Paramaters(s) : Type | Return Value : Type |
| --- | --- | --- |
| DoesGroupExist | svid : string | bool |
| GetGroupMemberIDs | | IDs : list\<string> | 
| GetName | | mame : string |
| GetSnapshot | | snapshot : GroupSnapshot | 
| GetSVIDFromName | name : string | SVID : string |
| Group | svid : string <br> auth_key : string | |
| HasGroupPermission | userSVID : string <br> permission : string | bool |

###### GroupTypes
| Name | Type | Value |
| --- | --- | --- |
| Company | string | "Companies" |
| District | string | "District" |
| News | string | "News" |
| None | string | "Groups" |
| Political | string | "Parties" |

| Name | Paramaters(s) : Type | Return Value : Type |
| --- | --- | --- |
| GroupTypes | | |

##### GroupBan
| Name | Type | Value |
| --- | --- | --- |
| Group_Id | string |
| Id | string |
| User_Id | string |

##### GroupInvite
| Name | Type | Value |
| --- | --- | --- |
| Group_Id | string |
| Id | string |
| User_Id | string |

##### GroupMember
| Name | Type | Value |
| --- | --- | --- |
| Group_Id | string |
| Id | string |
| User_Id | string |

##### GroupRole
| Name | Type | Value |
| --- | --- | --- |
| Color | string |
| GroupId | string |
| Name | string |
| Permissions | string |
| RoleId | string |
| Salary | decimal |
| Weight | int |

##### GroupRoleMember
| Name | Type | Value |
| --- | --- | --- |
| Group_Id | string |
| Id | string |
| Role_Id | string |
| User_Id | string |

#### GroupSnapshot
| Name | Type | Value |
| --- | --- | --- |
| Credits_Invested | decimal |
| Default_Role_Id | string |
| Description | string |
| District_Id | string |
| Group_Category | string |
| Open | bool |
| Owner_Id | string |

#### User
| Name | Paramaters(s) : Type | Return Value : Type |
| --- | --- | --- |
| GetSVIDFromDiscord | discordid : ulong | svid : string |
| GetSVIDFromMinecraft | minecraftid : string | svid : string |
| GetSVIDFromUsername | username : string | svid : string |
| GetUsernameFromDiscord | discordid : string | username : string |
| GetUsernameFromMinecraft | minecraftid : string | username : string |
| GetDaysSinceLastMove | | days since last move : int |
| GetDiscordroles| | discord roles : list\<DiscordRoleData> |
| GetSnapshot | | snapshot : UserSnapshot |
| GetUsername | | username : string |
| HasDiscordRole | role : string | bool |
| SetAuthKey | auth : string |
| User | svid : string <br> auth_key : string |

#### UserSnapshot
| Name | Type | Value |
| --- | --- | --- |
| api_use_count | int | 
| comment_likes | int | 
| description | string | 
| discord_ban_count | int | 
| discord_id | ulong? | 
| discord_kick_count | int | 
| discord_last_commend_message | ulong | 
| discord_last_commend_hour | int | 
| discord_last_message_minute | int | 
| discord_message_count | int | 
| discord_message_xp | int | 
| discord_commends | int | 
| discord_commends_sent | int | 
| discord_game_xp | int | 
| discord_warning_count | int |
| district | string | 
| minecraft_id | string | 
| nationstate | string | 
| post_likes | int | 
| twitch_id | string |
| twitch_last_message_minute | int | 
| twitch_message_xp | int | 
| twitch_messages | int | 
| UserName | string | 

### Forums
#### ForumCategory
| Name | Type | Value |
| --- | --- | --- |
| CategoryID | string |
| Description | string |
| Parent | string |
| RoleAccess | string |
| Tags | string |

#### ForumComment
| Name | Type | Value |
| --- | --- | --- |
| CommentID | ulong |
| CommentOnID | ulong? |
| Content | string |
| PostOnID | ulong |
| Removed | bool |
| TimePosted | DateTime |
| UserId | string |

#### ForumCommentLike
| Name | Type | Value |
| --- | --- | --- |
| CommentID | ulong |
| GivenTo | string |
| LikeID | string |
| UserID | string |

#### ForumLike
| Name | Type | Value |
| --- | --- | --- |
| AddedBy | string |
| GivenTo | string |
| LikeID | string |
| Post | ulong |

#### ForumPost
| Name | Type | Value |
| --- | --- | --- |
| Author | string |
| Category | string |
| Content | string |
| Picture | bool |
| PostID | ulong |
| Removed | bool |
| Tags | string |
| TimePosted | DateTime |
| Title | string |

#### Notification
| Name | Type | Value |
| --- | --- | --- |
| Author | string |
| Content | string |
| Linkback | string |
| NotificationID | string |
| Seen | bool |
| Source | ulong |
| Target | string |
| TimeSent | DateTime |
| Title | string |
| Type | string |

### Government
#### District
| Name | Type | Value |
| --- | --- | --- |
| Description | string |
| Flag_Url | string |
| Group_Id | string |
| Name | string |
| Senator | string |

#### GovControls
| Name | Type | Value |
| --- | --- | --- |
| CapitalGainsTaxRate | decimal |
| CapitalGainsTaxRevenue | decimal |
| CorgiPayPercent | decimal |
| CorporateTaxRate | decimal |
| CorporateTaxRevenue | decimal |
| CrabPayPercent | decimal |
| GatyPayPercent | decimal |
| Id | string |
| InactivityTaxRate | decimal |
| InactivityTaxRevenue | decimal |
| OofPayPercent | decimal |
| PayrollTaxRate | decimal |
| PayrollTaxRevenue | decimal |
| SalesRevenue | decimal |
| SalesTaxRate | decimal |
| SalesTaxRevenue | decimal |
| SpleenPayPercent | decimal |
| UBIAccount | decimal |
| UBIBudgetPercent | decimal |
| UnrankedPayPercent | decimal |

#### Minister
| Name | Type | Value |
| --- | --- | --- |
| Ministry | string |
| UserID | string |

#### Ministry
| Name | Type | Value |
| --- | --- | --- |
| Description | string |
| Name | string |

#### Voting
##### CandidatePass
| Name | Type | Value |
| --- | --- | --- |
| Blacklist | bool |
| District | string |
| Id | string |
| Type | string |
| UserId | string |

##### Election
| Name | Type | Value |
| --- | --- | --- |
| Active | bool |
| District | string |
| End_Date | DateTime |
| Id | string |
| Start_Date | DateTime |
| Type | string |
| Winner_Id | string |

##### ElectionVote
##### Election
| Name | Type | Value |
| --- | --- | --- |
| Choice_Id | string |
| Date | DateTime |
| Election_Id | string |
| Id | string |
| Invalid | bool |
| User_Id | string |

### Nerdcraft
#### Player
| Name | Type | Value |
| --- | --- | --- |
| ApiKey | string |
| Credits | decimal |
| DiscordRoles | string |
| Job | string |
| LastKitUse | DateTime |
| Name | string |
| SVID | string |
| UUID | string |

#### Plot
| Name | Type | Value |
| --- | --- | --- |
| Builders | string |
| ForSale | bool |
| GroupOwned | bool |
| Id | string |
| NoLimit | bool |
| Owner | string |
| Price | float |
| Public | bool |
| Title | string |
| X | int |
| Z | int |

### News
#### NewsPost
| Name | Type | Value |
| --- | --- | --- |
| AuthorID | string |
| Content | string |
| DiscussionID | ulong |
| GroupID | string |
| ImageURL | string |
| PostID | string |
| Tags | string |
| Timestamp | DateTime |
| Title | string |

#### PressPass
| Name | Type | Value |
| --- | --- | --- |
| GroupID | string |

### Oauth2
#### AuthToken
| Name | Type | Value |
| --- | --- | --- |
| AppId | string |
| Id | string |
| Scope | string |
| Time | DateTime |
| UserId | string |

#### OauthApp
| Name | Type | Value |
| --- | --- | --- |
| AppId | string |
| Id | string |
| Scope | string |
| Time | DateTime |
| UserId | string |
