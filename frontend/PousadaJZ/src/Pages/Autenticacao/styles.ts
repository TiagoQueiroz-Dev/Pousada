import { width } from "@mui/system";

const useStyles = () => ({
  background: {
    padding: 0,
    position: "fixed",
    zIndex: -10,
    top: 0,
    left: 0,
    width: "100%",
    height: "100%",
    background:
      "linear-gradient(rgba(255, 246, 0, 0.8), rgba(234, 147, 95, 0.8))",
    backgroundSize: "cover",
    backgroundRepeat: "no-repeat",
    backgroundPosition: "center",
  },
  tela: {
    width: "100%",
    height: "100%",
    display: "flex",
    justifyContent: "center",
    alignItems: "center",
  },
  container: {
    display: "flex",
    marginTop: "50px",
    width: "100%",
    height: "100%",
    maxWidth: "712.5px",
    maxHeight: "525px",
    backgroundColor: "#DE7637",
    borderRadius: "6px",
    overflow: "hidden",
  },
  coqueiro: {
    transform: "scale(0.75) translateX(-245px)",
    transformOrigin: "left top",
    marginLeft: "-14.06px",
  },
  coqueiroBox: {
    width: "234.225px",
    height: "525px",
    borderRight: "5px solid white",
    overflow: "hidden",
  },
  login: {
    zIndex: 0,
    display: "flex",
    justifyContent: "center",
    width: "100%",
    margin: "50px",
  },
  logo: {
    height: "106px",
    width: "300px",
    backgroundColor: "white",
  },
});

export default useStyles;
