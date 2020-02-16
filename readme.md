# Altseed2 Document

[Altseed2](https://github.com/altseed/altseed2-csharp)のドキュメント

# 生成に必要なもの

- Visual Studio
  - ほかのC#コンパイラでいけるかは不明
- [DocFX](https://github.com/dotnet/docfx)
  - `choco install docfx` するか ↑からバイナリを落としてパスを通す

# 生成

```
docfx metadata
docfx build
```

`docfx --serve` とするとリッチなページがみられる。（CORSに引っかからない）

`Site\Api` 以下にクラス一覧のファイルが生成される