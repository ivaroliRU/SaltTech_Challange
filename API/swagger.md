**Contact information:**  
ivartheoli@ru.is  

### /products

#### GET
##### Responses

| Code | Description | Schema |
| ---- | ----------- | ------ |
| 200 | Success | [ [Product](#product) ] |

### /products/{productId}

#### GET
##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| productId | path |  | Yes | integer |

##### Responses

| Code | Description | Schema |
| ---- | ----------- | ------ |
| 200 | Success | [Product](#product) |
| 404 | Not Found |  |

### /products/{productId}/orders

#### GET
##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| productId | path |  | Yes | integer |

##### Responses

| Code | Description | Schema |
| ---- | ----------- | ------ |
| 200 | Success | [ [Order](#order) ] |
| 404 | Not Found |  |

#### POST
##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| productId | path |  | Yes | integer |

##### Responses

| Code | Description |
| ---- | ----------- |
| 204 | Success - No Content |
| 404 | Not Found |

### /orders

#### GET
##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

#### POST
##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| order | body | The order to create. | No | [ [Order](#order) ] |

##### Responses

| Code | Description |
| ---- | ----------- |
| 204 | Success - No Content |
| 400 |  |

### Models


#### Order

| Name | Type | Description | Required |
| ---- | ---- | ----------- | -------- |
| id | integer |  | No |
| productId | integer |  | Yes |

#### Product

| Name | Type | Description | Required |
| ---- | ---- | ----------- | -------- |
| id | integer |  | Yes |
| name | string |  | Yes |
| imageSource | string |  | No |
| price | integer |  | No |
| stock | integer |  | No |