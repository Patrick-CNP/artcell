


any codes, notes and links on running ipfs 

0. IPFS


https://ipfs.io/ p2p storage node (part of distributed database)

https://github.com/ipfs/awesome-ipfs - links to data explorer and other

Add in for Firefox after running daemon https://github.com/ipfs-shipyard/ipfs-companion


1. Run daemon and never close it
```
set IPFS_PATH=D:\artcell\tools\go-ipfs\data
D:\artcell\tools\go-ipfs\ipfs  daemon
```

2. Upload file
```
set IPFS_PATH=D:\artcell\tools\go-ipfs\data
D:\artcell\tools\go-ipfs\ipfs add D:\artcell\research\content\5407771.jpg
```

3. Check

3.1 Local
```
set IPFS_PATH=D:\artcell\tools\go-ipfs\data
D:\artcell\tools\go-ipfs\ipfs get <HASH FROM ADD>
```

3.2 Remote
http://localhost:5001/ipfs/QmSDgpiHco5yXdyVTfhKxr3aiJ82ynz8V14QcGKicM3rVh/#/



4. Download via API in dotnet

https://github.com/richardschneider/net-ipfs-http-client - dotnet api


