var util = require('/utils/util.js')
var that = this
//app.js
App({
  session: {
    userInfo: null,
    encryptedData: null,
    iv: null,
    rawData: null,
    signature: null,
    sessionCode: null,
    sessionKey: null,
    openId: null,
    unionId: null,
    logged: false
  },
  checkSessionIsReady: function () {
    // 这个地方非常重要，重置data{}里数据时候setData方法的this应为以及函数的this, 如果在下方的sucess直接写this就变成了wx.request()的this了  
    var that = this
    if (!this.session.logged) {
      wx.login({
        success: res => {
          //发送 res.code 到后台换取 openId, sessionKey, unionId         
          this.session.sessionCode = res.code// res.code 每次登录都将不一致      
          console.log("this.session.sessionCode", this.session.sessionCode)
          wx.getSetting({
            success: res => {
              if (res.authSetting['scope.userInfo', 'scope.userLocation']) {
                //已经授权，可以直接调用 getUserInfo 获取头像昵称，不会弹框                        
                wx.getUserInfo({
                  success: res => {
                    // 可以将 res 发送给后台解码出 unionId
                    // 由于 getUserInfo 是网络请求，可能会在 Page.onLoad 之后才返回
                    // 所以此处加入 callback 以防止这种情况                  
                    if (this.userInfoReadyCallback) {//调用 index.js中的userInfoReadyCallback
                      this.userInfoReadyCallback(res)
                    }
                    this.getEncryptedData(this.session)
                  }
                })
                wx.getPhoneNumber(e)
              }
              else {
                wx.getUserInfo({
                  withCredentials: true,
                  success: function (res_user) {
                    that.userInfoReadyCallback(res_user)
                    that.getEncryptedData(that.session)
                  },
                  fail: function () {
                    //开启注册/登陆流程
                    console.log("授权失败")
                  }
                })
              }
            }
          })

        },
        fail: err => {
          //授权失败时事件委托
          //启动小程序内注册登录
          console.log(err)
        }
      }
      )
    }
  },
  userInfoReadyCallback: function (res) {
    this.session.userInfo = res.userInfo
    this.session.rawData = res.rawData
    this.session.encryptedData = res.encryptedData
    this.session.signature = res.signature
    this.session.iv = res.iv
    //获取隐私信息 
  },
  checkSession: function () {
    wx.checkSession({
      success: function () { },
      fail: function () {
        this.checkSessionIsReady()
      }
    })
  },
  getEncryptedData: function (session) {
    wx.request({
      //后台接口地址
      url: 'http://localhost:50333/api/yovip/GetAccessToken',
      //url:"http://192.168.0.106/api/wechat/DecodeUserInfo",
      //url: 'https://www.yourc.club/api/wechat/DecodeUserInfo',
      //url:"http://localhost:50333/api/yovip/DecodeUserInfo",
      // data: {
      //   code: session.sessionCode,
      //   encryptedData: session.encryptedData,
      //   iv: session.iv,
      //   signature: session.signature
      // },
      data:{
        appid:"wx0c644f8027d78c74",
        secret:"f1681068dfcd75ef2d7dff14cb3b5fae"
      },
      method: 'GET',
      header: {
        'content-type': 'application/json'
      },
      success: function (res) {
        //console.log(res.data)
        wx.navigateTo({
          url: res.data.show_qrcode_url
        })
        // var token = res.data.access_token
        // console.log(token)
      },
      fail: function (error) {
        console.log(error)
      }
    })

  },
  onLaunch: function () {
    var logs = wx.getStorageSync('logs') || []
    logs.unshift(Date.now())
    wx.setStorageSync('logs', logs)
    this.checkSessionIsReady()
  }
})