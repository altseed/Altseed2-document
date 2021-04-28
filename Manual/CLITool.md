# Altseed2.Tools (.NETツール)

Altseed2で使えるツールをまとめたものです。

```sh
# globalの場合
dotnet tool install -g Altseed2.Tools

# localの場合
dotnet new tool-manifeset
dotnet tool install Altseed2.Tools
```

でインストールして、

```
dotnet altseed2 <subcommand>
```

コマンドで実行できます。

## 利用可能なコマンド

### file

ファイルパッケージを作成するコマンドです。

```sh
dotnet altseed2 file -s {リソースフォルダ} -o {出力先ファイル名} [-p {パスワード}]
```

### font

静的フォントを作成するコマンドです。

```sh
dotnet altseed2 font -s {フォントファイル} -o {出力先a2f名} -c {使用したい文字列} [--size {サンプリングサイズ}]
```

### gui

ファイルパッケージの生成や静的フォントファイルの生成をGUI上で行うことができます。

```sh
dotnet altseed2 gui
```
