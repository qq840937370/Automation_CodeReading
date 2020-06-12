# Inv
## Prog
----
# Prog
## Module

----

# Data
## ScanData
## XML
- .Net原生生成XML
- 从struct info转XML
----
# Db
## Design
### Db Key
  ```SQL
  HospitalId 
  ScanId TEXT(50) DateTime.Now.ToString("yyyyMMddhhmmss") + CountToday.ToString("D3")
  ```
## Framwork
### ~~Plan 1~~~
 - Wpf主程序 + 各种其他模块
 - Console副程序 + Wcf服务
 - 共享内存存取Data

### **Plan2**
- Wpf主程序 + 各种其他模块
- Console副程序 + Wcf服务
- ASP.NET browser程序 
- 操作Db
## TODO
- [ ] wcf+ wpf